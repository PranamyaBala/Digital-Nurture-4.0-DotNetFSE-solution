public class SingletonTest{
    static class Logger{
        //1.private static instance of Logger
        private static Logger instance; 

        //2.private constructor
        private Logger(){
            System.out.println("Logger initialized");
        }

        //3.public static method to get instance of logger class
        public static Logger getInstance(){
            if  (instance==null){
                instance=new Logger();
            }
            return instance;
        }
        public void log(String message){
            System.out.println("Log: "+message);
        }
    }
    
    public static void main(String[] args) {
        Logger logger1 = Logger.getInstance();
        Logger logger2 = Logger.getInstance();
        logger1.log("First log message");
        logger1.log("Second log message");
        if (logger1==logger2){
            System.out.println("Both logger instances are same");
        }else{
            System.out.println("Logger instances are different");

        }
    }

}


