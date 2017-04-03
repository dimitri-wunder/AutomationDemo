//package <set your test package>;
import com.experitest.client.*;
import org.junit.*;
/**
 *
*/
public class BasicLogintest {
    private String host = "localhost";
    private int port = 8889;
    private String projectBaseDirectory = "C:\\Users\\Dimitri\\workspace\\project2";
    protected Client client = null;

    @Before
    public void setUp(){
        client = new Client(host, port, true);
        client.setProjectBaseDirectory(projectBaseDirectory);
        client.setReporter("xml", "reports", "BasicLogintest");
    }

    @Test
    public void testBasicLogintest(){
        client.setDevice("adb:GT-I9195");
        client.applicationClearData("org.wundercar.android");
        client.click("NATIVE", "xpath=//*[@text='Wunder']", 0, 1);
        if(client.waitForElement("NATIVE", "xpath=//*[@text='Log in']", 0, 10000)){
            // If statement
        }
        client.click("default", "Log in", 0, 1);
        if(client.waitForElement("NATIVE", "xpath=//*[@id='email']", 0, 10000)){
            // If statement
        }
        client.click("NATIVE", "xpath=//*[@id='email']", 0, 1);
        client.elementSendText("NATIVE", "xpath=//*[@id='email']", 0, "tester+hamburg@wunder.org");
        client.click("NATIVE", "xpath=//*[@id='password']", 0, 1);
        client.sendText("sharetest");
        client.closeKeyboard();
        client.click("NATIVE", "xpath=//*[@id='cta']", 0, 1);
        if(client.waitForElement("NATIVE", "xpath=//*[@text='Account']", 0, 10000)){
            // If statement
        }
        client.startMultiGesture("");
    }

    @After
    public void tearDown(){
        // Generates a report of the test case.
        // For more information - https://docs.experitest.com/display/public/SA/Report+Of+Executed+Test
        client.generateReport(false);
        // Releases the client so that other clients can approach the agent in the near future. 
        client.releaseClient();
    }
}
