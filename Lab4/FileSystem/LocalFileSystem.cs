namespace Lab4.FileSystem;

public class LocalFileSystem : IFileSystem
{
    public OperationResult MoveFile(string initPath, string finalPath)
    {
        if (!File.Exists(initPath))
        {
            return new OperationResult.Fail($"file not found at: {initPath}");
        }

        string fileName = Path.GetFileName(initPath);
        finalPath = Path.Combine(finalPath, fileName);
        if (File.Exists(finalPath))
        {
            return new OperationResult.Fail($"file already exists: {finalPath}");
        }

        string? directory = Path.GetDirectoryName(finalPath);
        if (directory != null && !Directory.Exists(directory))
        {
            return new OperationResult.Fail("directory not found");
        }

        try
        {
            File.Move(initPath, finalPath);
            return new OperationResult.Success();
        }
        catch (UnauthorizedAccessException ex)
        {
            return new OperationResult.Fail($"access denied : {ex.Message}");
        }
        catch (IOException ex)
        {
            return new OperationResult.Fail($"IOException : {ex.Message}");
        }
    }

    public OperationResult CopyFile(string initPath, string finalPath)
    {
        if (!File.Exists(initPath))
        {
            return new OperationResult.Fail($"file not found at : {initPath}");
        }

        string fileName = Path.GetFileName(initPath);
        finalPath = Path.Combine(finalPath, fileName);
        if (File.Exists(finalPath))
        {
            return new OperationResult.Fail($"file already exists : {finalPath}");
        }

        try
        {
            File.Copy(initPath, finalPath);
            return new OperationResult.Success();
        }
        catch (UnauthorizedAccessException ex)
        {
            return new OperationResult.Fail($"access denied : {ex.Message}");
        }
        catch (IOException ex)
        {
            return new OperationResult.Fail($"IOException : {ex.Message}");
        }
    }

    public OperationResult DeleteFile(string path)
    {
        if (!File.Exists(path))
        {
            return new OperationResult.Fail($"file not found at : {path}");
        }

        try
        {
            File.Delete(path);
            return new OperationResult.Success();
        }
        catch (UnauthorizedAccessException ex)
        {
            return new OperationResult.Fail($"access denied : {ex.Message}");
        }
        catch (IOException ex)
        {
            return new OperationResult.Fail($"IOException : {ex.Message}");
        }
    }

    public OperationResult RenameFile(string initPath, string newFileName)
    {
        if (!File.Exists(initPath))
        {
            return new OperationResult.Fail($"file not found at : {initPath}");
        }

        string? directory = Path.GetDirectoryName(initPath);
        if (directory is null || !Directory.Exists(directory))
        {
            return new OperationResult.Fail("directory not found");
        }

        string finalPath = Path.Combine(directory, newFileName);
        if (File.Exists(finalPath))
        {
            return new OperationResult.Fail($"file with this name already exists at {initPath}");
        }

        try
        {
            File.Move(initPath, finalPath);
            return new OperationResult.Success();
        }
        catch (IOException ex)
        {
            return new OperationResult.Fail($"IOException: {ex.Message}");
        }
        catch (UnauthorizedAccessException ex)
        {
            return new OperationResult.Fail($"access denied: {ex.Message}");
        }
    }

    public string? ShowFile(string path)
    {
        return File.Exists(path) ? File.ReadAllText(path) : null;
    }

    public string Combine(string path, string name)
    {
        return Path.Combine(path, name);
    }

    public bool IsPathRooted(string path)
    {
        return Path.IsPathRooted(path);
    }

    public bool DirectoryExists(string path)
    {
        return Directory.Exists(path);
    }

    public string? GetDirectoryName(string path)
    {
        return Path.GetDirectoryName(path);
    }

    public IList<string> GetFiles(string path)
    {
        return Directory.GetFiles(path);
    }

    public IList<string> GetDirectories(string path)
    {
        return Directory.GetDirectories(path);
    }

    public string? GetFileName(string? path)
    {
        return Path.GetFileName(path);
    }

    public string GetFullPath(string path)
    {
        return Path.GetFullPath(path);
    }
}