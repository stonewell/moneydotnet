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