package work5;

import javax.servlet.ServletException;
import javax.servlet.http.*;
import java.io.IOException;

public class FormServlet extends HttpServlet {
    @Override
    protected void doPost(HttpServletRequest request, HttpServletResponse response) 
    		throws ServletException, IOException {
    	request.setCharacterEncoding("UTF-8");
        response.setContentType("text/html;charset=UTF-8");
    	
    	String name=request.getParameter("name");
        String email=request.getParameter("email");

        response.setContentType("text/html;charset=UTF-8");
        response.getWriter().write("<html><body>");
        response.getWriter().write("<h1>相关数据输出</h1>");
        response.getWriter().write("<p>Name: "+name+"</p>");
        response.getWriter().write("<p>Email: "+email+"</p>");
        response.getWriter().write("</body></html>");
    }
}
