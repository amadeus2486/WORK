package work5;

import java.io.IOException;
import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

public class CircleServlet extends HttpServlet {
    @Override
    protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        double radius = Double.parseDouble(request.getParameter("radius"));
        double circumference=2*Math.PI*radius;
        double area=Math.PI*radius*radius;

        response.setContentType("text/html;charset=UTF-8");
        response.getWriter().write("<html><body>");
        response.getWriter().write("<h1>计算结果:</h1>");
        response.getWriter().write("<p>半径为: "+radius+"</p>");
        response.getWriter().write("<p>周长为: "+circumference+"</p>");
        response.getWriter().write("<p>面积为: "+area+"</p>");
        response.getWriter().write("</body></html>");
    }
}
