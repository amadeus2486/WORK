package work5;
import javax.servlet.*;
import javax.servlet.http.HttpServletRequest;
import java.io.IOException;

public class IPFilter implements Filter {

    @Override
    public void init(FilterConfig filterConfig) throws ServletException {
    }

    @Override
    public void doFilter(ServletRequest request, ServletResponse response,FilterChain chain)
            throws IOException, ServletException {
        HttpServletRequest httpRequest=(HttpServletRequest) request;
        String ip=httpRequest.getRemoteAddr();
        System.out.println("Request from IP: " + ip);
        if ("127.0.0.1".equals(ip) || "0:0:0:0:0:0:0:1".equals(ip) 
        		|| ip.matches("^219\\.218\\.\\d+\\.\\d+$")) {
            chain.doFilter(request,response);
        }
        else{
            httpRequest.getRequestDispatcher("/error.jsp").forward(request,response);
        }
    }
    @Override
    public void destroy() {
    }
}
