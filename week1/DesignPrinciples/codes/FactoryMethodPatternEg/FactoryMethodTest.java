public class FactoryMethodTest {

    // Document interface
    interface Document {
        void open();
    }

    // Concrete document types
    static class WordDocument implements Document {
        public void open() {
            System.out.println("Opening Word document.");
        }
    }

    static class PdfDocument implements Document {
        public void open() {
            System.out.println("Opening PDF document.");
        }
    }

    static class ExcelDocument implements Document {
        public void open() {
            System.out.println("Opening Excel document.");
        }
    }

    // Abstract factory
    abstract static class DocumentFactory {
        public abstract Document createDocument();
    }

    // Concrete factories
    static class WordFactory extends DocumentFactory {
        public Document createDocument() {
            return new WordDocument();
        }
    }

    static class PdfFactory extends DocumentFactory {
        public Document createDocument() {
            return new PdfDocument();
        }
    }

    static class ExcelFactory extends DocumentFactory {
        public Document createDocument() {
            return new ExcelDocument();
        }
    }

    // Main method to test factory
    public static void main(String[] args) {
        DocumentFactory wordFactory = new WordFactory();
        Document wordDoc = wordFactory.createDocument();
        wordDoc.open();

        DocumentFactory pdfFactory = new PdfFactory();
        Document pdfDoc = pdfFactory.createDocument();
        pdfDoc.open();

        DocumentFactory excelFactory = new ExcelFactory();
        Document excelDoc = excelFactory.createDocument();
        excelDoc.open();
    }
}
