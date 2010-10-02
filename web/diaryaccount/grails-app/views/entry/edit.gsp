<%@ page import="angelstone.diaryaccount.Entry" %>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8"/>
        <meta name="layout" content="main" />
        <title>Edit Entry</title>
    </head>
    <body>
        <div class="nav">
            <span class="menuButton"><a class="home" href="${resource(dir:'')}">Home</a></span>
            <span class="menuButton"><g:link class="list" action="list">Entry List</g:link></span>
            <span class="menuButton"><g:link class="create" action="create">New Entry</g:link></span>
        </div>
        <div class="body">
            <h1>Edit Entry</h1>
            <g:if test="${flash.message}">
            <div class="message">${flash.message}</div>
            </g:if>
            <g:hasErrors bean="${entryInstance}">
            <div class="errors">
                <g:renderErrors bean="${entryInstance}" as="list" />
            </div>
            </g:hasErrors>
            <g:form method="post" >
                <input type="hidden" name="id" value="${entryInstance?.id}" />
                <input type="hidden" name="version" value="${entryInstance?.version}" />
                <div class="dialog">
                    <table>
                        <tbody>
                        
                            <tr class="prop">
                                <td valign="top" class="name">
                                    <label for="fangxiang">Fangxiang:</label>
                                </td>
                                <td valign="top" class="value ${hasErrors(bean:entryInstance,field:'fangxiang','errors')}">
                                    <g:textField name="fangxiang" value="${fieldValue(bean: entryInstance, field: 'fangxiang')}" />
                                </td>
                            </tr> 
                        
                            <tr class="prop">
                                <td valign="top" class="name">
                                    <label for="name">Name:</label>
                                </td>
                                <td valign="top" class="value ${hasErrors(bean:entryInstance,field:'name','errors')}">
                                    <g:textField name="name" maxlength="50" value="${entryInstance?.name}" />
                                </td>
                            </tr> 
                        
                            <tr class="prop">
                                <td valign="top" class="name">
                                    <label for="amount">Amount:</label>
                                </td>
                                <td valign="top" class="value ${hasErrors(bean:entryInstance,field:'amount','errors')}">
                                    <g:textField name="amount" value="${fieldValue(bean: entryInstance, field: 'amount')}" />
                                </td>
                            </tr> 
                        
                            <tr class="prop">
                                <td valign="top" class="name">
                                    <label for="description">Description:</label>
                                </td>
                                <td valign="top" class="value ${hasErrors(bean:entryInstance,field:'description','errors')}">
                                    <g:textArea name="description" cols="40" rows="5" value="${entryInstance?.description}" />
                                </td>
                            </tr> 
                        
                            <tr class="prop">
                                <td valign="top" class="name">
                                    <label for="fangshi_name">Fangshiname:</label>
                                </td>
                                <td valign="top" class="value ${hasErrors(bean:entryInstance,field:'fangshi_name','errors')}">
                                    <g:textField name="fangshi_name" value="${entryInstance?.fangshi_name}" />
                                </td>
                            </tr> 
                        
                            <tr class="prop">
                                <td valign="top" class="name">
                                    <label for="fenlei_name">Fenleiname:</label>
                                </td>
                                <td valign="top" class="value ${hasErrors(bean:entryInstance,field:'fenlei_name','errors')}">
                                    <g:textField name="fenlei_name" value="${entryInstance?.fenlei_name}" />
                                </td>
                            </tr> 
                        
                            <tr class="prop">
                                <td valign="top" class="name">
                                    <label for="updated">Updated:</label>
                                </td>
                                <td valign="top" class="value ${hasErrors(bean:entryInstance,field:'updated','errors')}">
                                    <g:datePicker name="updated" precision="day" value="${entryInstance?.updated}"  />
                                </td>
                            </tr> 
                        
                            <tr class="prop">
                                <td valign="top" class="name">
                                    <label for="created">Created:</label>
                                </td>
                                <td valign="top" class="value ${hasErrors(bean:entryInstance,field:'created','errors')}">
                                    <g:datePicker name="created" precision="day" value="${entryInstance?.created}"  />
                                </td>
                            </tr> 
                        
                        </tbody>
                    </table>
                </div>
                <div class="buttons">
                    <span class="button"><g:actionSubmit class="save" value="Update" /></span>
                    <span class="button"><g:actionSubmit class="delete" onclick="return confirm('Are you sure?');" value="Delete" /></span>
                </div>
            </g:form>
        </div>
    </body>
</html>
