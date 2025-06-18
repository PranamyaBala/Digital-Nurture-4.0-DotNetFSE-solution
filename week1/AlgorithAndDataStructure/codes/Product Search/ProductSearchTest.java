import java.util.Arrays;
import java.util.Comparator;

public class ProductSearchTest {

    // Product class with attributes
    static class Product {
        int productId;
        String productName;
        String category;

        public Product(int id, String name, String category) {
            this.productId = id;
            this.productName = name;
            this.category = category;
        }

        public String toString() {
            return productId + " - " + productName + " (" + category + ")";
        }
    }

    // Linear Search
    public static int linearSearch(Product[] products, String name) {
        for (int i = 0; i < products.length; i++) {
            if (products[i].productName.equalsIgnoreCase(name)) {
                return i;
            }
        }
        return -1;
    }

    // Binary Search (requires sorted array)
    public static int binarySearch(Product[] products, String name) {
        int left = 0, right = products.length - 1;
        while (left <= right) {
            int mid = (left + right) / 2;
            int cmp = name.compareToIgnoreCase(products[mid].productName);
            if (cmp == 0)
                return mid;
            else if (cmp < 0)
                right = mid - 1;
            else
                left = mid + 1;
        }
        return -1;
    }

    // Main method to test searches
    public static void main(String[] args) {
        Product[] products = {
            new Product(101, "Shoes", "Footwear"),
            new Product(102, "Laptop", "Electronics"),
            new Product(103, "Watch", "Accessories"),
            new Product(104, "Phone", "Electronics")
        };

        System.out.println("Linear Search for 'Laptop':");
        int linearIndex = linearSearch(products, "Laptop");
        if (linearIndex != -1)
            System.out.println("Found at index: " + linearIndex + " -> " + products[linearIndex]);
        else
            System.out.println("Not found.");

        // Sort before binary search
        Arrays.sort(products, Comparator.comparing(p -> p.productName.toLowerCase()));

        System.out.println("\nBinary Search for 'Laptop':");
        int binaryIndex = binarySearch(products, "Laptop");
        if (binaryIndex != -1)
            System.out.println("Found at index: " + binaryIndex + " -> " + products[binaryIndex]);
        else
            System.out.println("Not found.");
    }
}
