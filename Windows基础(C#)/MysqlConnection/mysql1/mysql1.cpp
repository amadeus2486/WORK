/*#include <mysql.h>  
#include <stdio.h>  

int main() {
    MYSQL* conn;
    MYSQL_RES* res;
    MYSQL_ROW row;

    // 初始化连接  
    conn = mysql_init(NULL);

    // 连接到数据库  
    if (!mysql_real_connect(conn, "127.0.0.1", "root", "root", "s-t", 0, NULL, 0)) {
        fprintf(stderr, "%s\n", mysql_error(conn));
        exit(1);
    }

    // 调用存储过程（假设存储过程名为my_procedure，没有参数）  
    if (mysql_query(conn, "CALL result3()")) {
        fprintf(stderr, "%s\n", mysql_error(conn));
        exit(1);
    }

    // 检查存储过程的结果（如果有的话）  
    res = mysql_use_result(conn);
    while ((row = mysql_fetch_row(res)) != NULL) {
        // 处理结果集  
        printf("%d\n", row[0]); // 假设结果集有一个字符串列  
    }
    mysql_free_result(res);

    // 调用函数（假设函数名为my_function，没有参数，返回一个字符串）  
    char query[256];
    snprintf(query, sizeof(query), "SELECT my_function()");
    if (mysql_query(conn, query)) {
        fprintf(stderr, "%s\n", mysql_error(conn));
        exit(1);
    }

    // 检查函数的结果  
    res = mysql_use_result(conn);
    row = mysql_fetch_row(res);
    if (row) {
        printf("Function result: %s\n", row[0]); // 假设函数返回一个字符串  
    }
    mysql_free_result(res);

    // 关闭连接  
    mysql_close(conn);

    return 0;
}*/
#include <stdio.h>
#include<iostream>
#include <mysql.h>
using namespace std;

int main() {
    char host[10] = "127.0.0.1";			//IP 
    char user[5] = "root";					//用户 
    char password[12] = "root";		//密码 
    char database[6] = "s-t";				//连接的数据库名称数据库 
    int	 port = 3306; 						//连接的端口号 默认为3306 

    MYSQL* conn;							//设置数据库连接句柄 
    conn = mysql_init(NULL);				//初始化连接句柄 

    if (!conn) 
    {
        printf("初始化失败！");
        return EXIT_FAILURE;
    }

    conn = mysql_real_connect(conn, host, user, password, database, port, NULL, 0);//连接数据库 
    if (conn)  
        printf("数据库连接成功！");										//判断数据库是否连接成功 
    else 
    {
        printf("数据库连接失败，错误：%s", mysql_error(conn));        //失败直接关闭
        mysql_close(conn);
        return EXIT_FAILURE;
    }

    if (mysql_set_character_set(conn, "GBK"))    //处理字符编码，解决乱码
        printf("字符集设置错误！\n");
    else   
        printf("字符集设置成功！\n");

    char query1[] = "call result2('离散数学')";   //撰写申请
    if (mysql_query(conn, query1))    
        printf("查询失败，错误：%s\n", mysql_error(conn));
    else    
        printf("查询成功！\n");

    MYSQL_RES* res1;
    res1 = mysql_use_result(conn);//获取结果

    MYSQL_ROW row1;//设置行结果容器 
    while (row1 = mysql_fetch_row(res1))    //获取行结果 
    {
        for (int t = 0; t < mysql_num_fields(res1); t++)   //将行结果分列输出 
            printf("%s\t", row1[t]);
        printf("\n");
    }

    /*char query2[] = "select fun1('李勇')";//select * from course call result2('离散数学')
    if (mysql_query(conn, query2))    
        printf("查询失败，错误：%s\n", mysql_error(conn));
    else    
        printf("查询成功！\n");

    MYSQL_RES* res2;
    res2 = mysql_use_result(conn);//获取结果

    MYSQL_ROW row2;//设置行结果容器 
    while (row2 = mysql_fetch_row(res2)) 
    {//获取行结果 
        for (int t = 0; t < mysql_num_fields(res2); t++)//将行结果分列输出 
            printf("%s\t", row2[t]);
        printf("\n");
    }*/

    mysql_free_result(res1);//释放结果集
    //mysql_free_result(res2);//释放结果集 
    mysql_close(conn);//关闭数据库连接 
    return 0;
}

