package work5;
import javax.servlet.*;
import javax.servlet.http.HttpServletRequest;
import java.io.IOException;
import java.util.Date;
import java.util.logging.FileHandler;
import java.util.logging.Logger;
import java.util.logging.SimpleFormatter;

public class LogFilter implements Filter {
    private static final Logger logger=Logger.getLogger(LogFilter.class.getName());
    private FileHandler fileHandler;

    @Override
    public void init(FilterConfig filterConfig) throws ServletException {
        try {
            fileHandler=new FileHandler("../code/work/log.txt",true);
            logger.addHandler(fileHandler);
            SimpleFormatter formatter=new SimpleFormatter();
            fileHandler.setFormatter(formatter);
        } catch (IOException e) {
            throw new ServletException("建立日志失败！",e);
        }
    }

    @Override
    public void doFilter(ServletRequest request, ServletResponse response, FilterChain chain)
            throws IOException, ServletException {
        HttpServletRequest httpRequest=(HttpServletRequest) request;
        String ip=httpRequest.getRemoteAddr();
        String host=httpRequest.getRemoteHost();
        String uri=httpRequest.getRequestURI();
        Date date=new Date();
        String log=String.format("\n访问时间: %s\n远程请求IP: %s\n远程主机名: %s\n客户请求的资源URI: %s\n",
                date.toString(),ip,host,uri);
        logger.info(log);
        chain.doFilter(request, response);
    }

    @Override
    public void destroy() {
        if (fileHandler!=null) {
            fileHandler.close();
        }
    }
}
