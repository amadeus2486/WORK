package work5;

import java.io.IOException;
import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;


public class RegisterServlet extends HttpServlet {
    @Override
    protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
    	request.setCharacterEncoding("UTF-8");
        response.setContentType("text/html;charset=UTF-8");
    	
    	String name=request.getParameter("name");
        String gender=request.getParameter("gender");
        String dob=request.getParameter("dob");
        String ethnicity=request.getParameter("ethnicity");
        String intro=request.getParameter("intro");

        request.setAttribute("name", name);
        request.setAttribute("gender", gender);
        request.setAttribute("dob", dob);
        request.setAttribute("ethnicity", ethnicity);
        request.setAttribute("intro", intro);

        request.getRequestDispatcher("Output.jsp").forward(request, response);
    }
}
