<%@ page import="angelstone.diaryaccount.Entry" %>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8"/>
        <meta name="layout" content="main" />
        <title>Entry List</title>
    </head>
    <body>
        <div class="nav">
            <span class="menuButton"><a class="home" href="${resource(dir:'')}">Home</a></span>
            <span class="menuButton"><g:link class="create" action="create">New Entry</g:link></span>
        </div>
        <div class="body">
            <h1>Entry List</h1>
            <g:if test="${flash.message}">
            <div class="message">${flash.message}</div>
            </g:if>
            <div class="list">
                <table>
                    <thead>
                        <tr>
                        
                   	        <g:sortableColumn property="id" title="Id" />
                        
                   	        <g:sortableColumn property="fangxiang" title="Fangxiang" />
                        
                   	        <g:sortableColumn property="name" title="Name" />
                        
                   	        <g:sortableColumn property="amount" title="Amount" />
                        
                   	        <g:sortableColumn property="description" title="Description" />
                        
                   	        <g:sortableColumn property="fangshi_name" title="Fangshiname" />
                        
                        </tr>
                    </thead>
                    <tbody>
                    <g:each in="${entryInstanceList}" status="i" var="entryInstance">
                        <tr class="${(i % 2) == 0 ? 'odd' : 'even'}">
                        
                            <td><g:link action="show" id="${entryInstance.id}">${fieldValue(bean:entryInstance, field:'id')}</g:link></td>
                        
                            <td>${fieldValue(bean:entryInstance, field:'fangxiang')}</td>
                        
                            <td>${fieldValue(bean:entryInstance, field:'name')}</td>
                        
                            <td>${fieldValue(bean:entryInstance, field:'amount')}</td>
                        
                            <td>${fieldValue(bean:entryInstance, field:'description')}</td>
                        
                            <td>${fieldValue(bean:entryInstance, field:'fangshi_name')}</td>
                        
                        </tr>
                    </g:each>
                    </tbody>
                </table>
            </div>
            <div class="paginateButtons">
                <g:paginate total="${entryInstanceTotal}" />
            </div>
        </div>
    </body>
</html>
