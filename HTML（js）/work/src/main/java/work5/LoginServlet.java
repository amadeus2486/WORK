package work5;

import javax.servlet.ServletException;
import javax.servlet.http.*;
import java.io.IOException;

public class LoginServlet extends HttpServlet {
    @Override
    protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        String username=request.getParameter("username");
        String password=request.getParameter("password");
        
        response.setContentType("text/html;charset=UTF-8");
        if ("54321".equals(username)&&"12345".equals(password)) {
            response.getWriter().write("<html><body>");
            response.getWriter().write("<h1>欢迎,"+username+"!</h1>");
            response.getWriter().write("</body></html>");
        } else {
            response.getWriter().write("<html><body>");
            response.getWriter().write("<h1>用户名或密码错误!</h1>");
            response.getWriter().write("</body></html>");
        }
    }
}