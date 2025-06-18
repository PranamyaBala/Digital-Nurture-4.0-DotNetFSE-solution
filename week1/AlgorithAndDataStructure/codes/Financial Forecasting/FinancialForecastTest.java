public class FinancialForecastTest {

    // Recursive method to forecast future value
    public static double forecastRecursive(double amount, double rate, int years) {
        if (years == 0)
            return amount;
        return forecastRecursive(amount * (1 + rate), rate, years - 1);
    }

    // Main method for testing
    public static void main(String[] args) {
        double initialAmount = 1000.0;
        double annualRate = 0.10; 
        int years = 5;

        // Using recursive method
        double recursiveForecast = forecastRecursive(initialAmount, annualRate, years);
        System.out.printf("Recursive Forecast after %d years: Rs%.2f\n", years, recursiveForecast);

    }
}

