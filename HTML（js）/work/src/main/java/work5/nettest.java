package work5;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;


public class nettest {
	static Connection con = null;
	static String cname = "数据库关联";
	static String url = "数据库链接";
	static String userid = "数据库名";
	static String pwd = "数据库密码";
	public static void main(String[] args) {
	try {
	Class.forName(cname);
	con = DriverManager.getConnection(url, userid, pwd);
	con.setAutoCommit(true);
	System.out.println("[SUCCESS]conn database");
	} catch (Exception e) {
	System.out.println("[FAIL]conn database：" + e.getMessage());
	}
	}
	public void disConn(Connection con) throws SQLException {
	if (con != null) {
	con.close();
	}
	}
}
