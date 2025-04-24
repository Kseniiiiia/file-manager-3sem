namespace Lab4.FileSystem;

public interface IFileSystem
{
    OperationResult MoveFile(string initPath, string finalPath);

    OperationResult CopyFile(string initPath, string finalPath);

    OperationResult DeleteFile(string path);

    OperationResult RenameFile(string initPath, string newFileName);

    string? ShowFile(string path);

    bool IsPathRooted(string path);

    string GetFullPath(string path);

    string Combine(string path, string name);

    bool DirectoryExists(string path);

    string? GetDirectoryName(string path);

    string? GetFileName(string? path);

    IList<string> GetFiles(string path);

    IList<string> GetDirectories(string path);
}
