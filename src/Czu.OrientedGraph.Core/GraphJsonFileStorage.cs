using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Czu.OrientedGraph.Core.Exceptions;
using Newtonsoft.Json;

namespace Czu.OrientedGraph.Core
{
    public sealed class GraphJsonFileStorage<T> : IGraphStorage<T> where T : IEdge
    {
        private const string FolderName = "SavedGraphs";
        private const string GraphNameSeparator = " ";
        private const string FileNameSeparator = "_";

        public Task UpsertAsync(SnapshotGraph<T> snapshot, CancellationToken cancellationToken = default)
        {
            if (snapshot is null)
            {
                throw new ArgumentNullException(nameof(snapshot));
            }

            try
            {
                TryCreateDirectory();
                var json = JsonConvert.SerializeObject(snapshot);
                File.WriteAllText(GetFilePath(new GraphName(snapshot.Name)), json);
            }
            catch (Exception)
            {
                throw new ModelException("File cannot be saved");
            }

            return Task.CompletedTask;
        }

        public Task<SnapshotGraph<T>> GetAsync(GraphName name, CancellationToken cancellationToken = default)
        {
            if (name is null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            var filePath = GetFilePath(name);
            string fileContent;
            try
            {
                fileContent = File.ReadAllText(filePath);
            }
            catch (Exception)
            {
                throw new ModelException($"File cannot be opened in path: {filePath}");
            }

            SnapshotGraph<T> snapshot;
            try
            {
                snapshot = JsonConvert.DeserializeObject<SnapshotGraph<T>>(fileContent);
            }
            catch (Exception)
            {
                throw new ModelException("File doesn't meet required structure");
            }

            return Task.FromResult(snapshot);
        }

        public Task<IEnumerable<GraphName>> GetAllGraphNamesAsync(CancellationToken cancellationToken = default) =>
            Task.FromResult(Directory.GetFiles(GetDirectoryPath()).Select(GetGraphNameFromFileName));

        public Task DeleteAsync(GraphName name, CancellationToken cancellationToken = default)
        {
            if (name is null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            try
            {
                File.Delete(GetFilePath(name));
            }
            catch (Exception)
            {
                throw new ModelException("File cannot be deleted");
            }

            return Task.CompletedTask;
        }

        public Task<bool> ExistsAsync(GraphName name, CancellationToken cancellationToken = default) =>
            name != null
                ? Task.FromResult(File.Exists(GetFilePath(name)))
                : throw new ArgumentNullException(nameof(name));

        private void TryCreateDirectory()
        {
            var directoryPath = GetDirectoryPath();
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
        }

        private string GetFileNameFromGraphName(GraphName name)
        {
            if (name is null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            if (Path.GetInvalidFileNameChars().Any(invalidChar => name.Value.Contains(invalidChar)))
            {
                throw new ModelException("Graph name should consists of only alphanumeric characters");
            }

            return $"{name.Value.Replace(GraphNameSeparator, FileNameSeparator)}.json";
        }

        private GraphName GetGraphNameFromFileName(string name) =>
            !string.IsNullOrWhiteSpace(name)
                ? new GraphName(Path.GetFileNameWithoutExtension(name).Replace(FileNameSeparator, GraphNameSeparator))
                : throw new ArgumentNullException(nameof(name));

        private string GetDirectoryPath() =>
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, FolderName);

        private string GetFilePath(GraphName name) =>
            name != null
                ? Path.Combine(GetDirectoryPath(), GetFileNameFromGraphName(name))
                : throw new ArgumentNullException(nameof(name));
    }
}