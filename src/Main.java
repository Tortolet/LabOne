import java.awt.*;
import java.awt.event.KeyEvent;

public class Main {
    public static void main(String[] args) {
        String test = "das1g";

//        while (true) {
//            try {
//                Robot robot = new Robot();
//                // нажатие и отжатие одновременнл
//                robot.keyPress(KeyEvent.VK_WINDOWS);
//                robot.keyRelease(KeyEvent.VK_WINDOWS);
//                Thread.sleep(3000);
//            } catch (AWTException | InterruptedException e) {
//                e.printStackTrace();
//            }
//        }


        if (test.matches(".*[a-z].*") && !test.matches(".*[0-9].*"))
            System.out.println("Yes!");
        else System.out.println("No");

        System.out.println(checkIt("1000111011"));
        System.out.println(checkIt("3255438764"));
        System.out.println(checkIt(""));

    }

    public static String checkIt(String out) {
        if (!out.isEmpty()) {
            if (out.matches(".*[0-1].*")) {
                System.out.println("В параметре содержаться 0 или 1");
                return null;
            }
        } else {
            System.out.println("В параметре ничего не содержится");
            return null;
        }
        return out;
    }
}