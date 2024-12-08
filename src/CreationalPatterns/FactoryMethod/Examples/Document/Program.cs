public interface IDocument
{
    void Open();
    void Close();
    void Save();
}

public class PdfDocument : IDocument
{
    public void Open()
    {
        Console.WriteLine("PDF Document opened");
    }

    public void Close()
    {
        Console.WriteLine("PDF Document closed");
    }

    public void Save()
    {
        Console.WriteLine("PDF Document saved");
    }
}

public class WordDocument : IDocument
{
    public void Open()
    {
        Console.WriteLine("Word Document opened");
    }

    public void Close()
    {
        Console.WriteLine("Word Document closed");
    }

    public void Save()
    {
        Console.WriteLine("Word Document saved");
    }
}

public class TextDocument : IDocument
{
    public void Open()
    {
        Console.WriteLine("Text Document opened");
    }

    public void Close()
    {
        Console.WriteLine("Text Document closed");
    }

    public void Save()
    {
        Console.WriteLine("Text Document saved");
    }
}

public abstract class DocumentFactory
{
    public abstract IDocument CreateDocument();
}

public class PdfDocumentFactory : DocumentFactory
{
    public override IDocument CreateDocument()
    {
        return new PdfDocument();
    }
}

public class WordDocumentFactory : DocumentFactory
{
    public override IDocument CreateDocument()
    {
        return new WordDocument();
    }
}

public class TextDocumentFactory : DocumentFactory
{
    public override IDocument CreateDocument()
    {
        return new TextDocument();
    }
}

class Program
{
    static void Main(string[] args)
    {
        DocumentFactory pdfFactory = new PdfDocumentFactory();
        IDocument pdfDocument = pdfFactory.CreateDocument();
        pdfDocument.Open();
        pdfDocument.Save();
        pdfDocument.Close();
        
        
        DocumentFactory wordFactory = new WordDocumentFactory();
        IDocument wordDocument = wordFactory.CreateDocument();
        wordDocument.Open();
        wordDocument.Save();
        wordDocument.Close();
        
        DocumentFactory textFactory = new TextDocumentFactory();
        IDocument textDocument = textFactory.CreateDocument();
        textDocument.Open();
        textDocument.Save();
        textDocument.Close();
    }
}