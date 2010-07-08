<div class="list, tableContainer" id="tableContainer">
  <table  border="0" cellpadding="0" cellspacing="0" width="100%" class="scrollTable"
          id="fenlei_summary_table_${summary?.type}"
          name="fenlei_summary_table_${summary?.type}"
          >
    <thead class="fixedHeader">
      <tr>
        <th class="sortable" align="left" valign="middle" height="16px">
          <table border="0" width="100%" cellpadding="0" cellspacing="0" class="headerTable" >
            <tr valign="middle" >
              <td nowrap valign="top" >
            <g:message code="${summary?.title}" default="${summary?.title_default}" />
            <g:select name="fenlei.id" id="fenlei.id"
                      from="${angelstone.money.grail.Fenlei.list()}"
                      optionKey="id" value="${richangjiaoyiInstance?.fenlei?.id}"
                      noSelection="['-1':'All Fen lei']"
                      onchange="${remoteFunction(
controller:'summary',
action:'ajaxGetItemSummary',
params:'\'fenlei=\' + escape(this.value) + \'&fangshi=\' + escape($(\'fangshi.id\').value) + \'&type=' + summary?.type + '\'',
update:'fenlei_summary_table_body_' + summary?.type )}"
                      />
            <g:select name="fangshi.id" id="fangshi.id"
                      from="${angelstone.money.grail.Fangshi.list()}"
                      optionKey="id" value="${richangjiaoyiInstance?.fangshi?.id}"
                      noSelection="['-1':'All Fang Shi']"
                      onchange="${remoteFunction(
controller:'summary',
action:'ajaxGetItemSummary',
params:'\'fangshi=\' + escape(this.value) + \'&fenlei=\' + escape($(\'fenlei.id\').value) + \'&type=' + summary?.type + '\'',
update:'fenlei_summary_table_body_' + summary?.type )}"
                      />
            </td>
      </tr>
  </table>
</th>
<th></th>
</tr>
<tr>
<g:sortableColumn property="name" title="${message(code: 'richangjiaoyi.name.label', default: 'Name')}" />
<g:sortableColumn property="amount" title="${message(code: 'richangjiaoyi.amount.label', default: 'Amount')}" />
</tr>
</thead>
<tbody class="scrollContent"
       id="fenlei_summary_table_body_${summary?.type}"
       name="fenlei_summary_table_body${summary?.type}"
       >
<g:each in="${summary?.fenleiList}" status="i" var="fenleiInstance">
  <tr class="${(i % 2) == 0 ? 'odd' : 'even'}">
    <td>${fenleiInstance[0]}</td>
    <td><g:formatNumber number="${fenleiInstance[1]}"  type="currency" currencyCode="CNY" currencySymbol=""/></td>
  </tr>
</g:each>
</tbody>
</table>
</div>
