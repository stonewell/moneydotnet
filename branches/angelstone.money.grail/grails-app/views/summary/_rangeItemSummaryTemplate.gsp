<div class="list, tableContainer" id="tableContainer">
<table border="0" width="100%" cellpadding="0" cellspacing="0" class="headerTable" >
  <tr valign="middle" >
    <td nowrap valign="top" colspan="2">
  <g:message code="${summary?.title}" default="${summary?.title_default}" />
  </td></tr>
  <tr><td>
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
  <table  border="0" cellpadding="0" cellspacing="0" width="100%" class="scrollTable"
          id="fenlei_summary_table_${summary?.type}"
          name="fenlei_summary_table_${summary?.type}"
          >
    <thead class="fixedHeader">
      <tr>
    <g:sortableColumn property="name" title="${message(code: 'richangjiaoyi.name.label', default: 'Name')}" />
    <g:sortableColumn property="amount" title="${message(code: 'richangjiaoyi.amount.label', default: 'Amount')}" />
    </tr>
    </thead>
    <g:render template="rangeItemSummaryBodyTemplate"  model="[summary:summary]"/>
  </table>
</div>
