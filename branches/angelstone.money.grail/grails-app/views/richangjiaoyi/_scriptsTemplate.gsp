<g:javascript library="prototype" />
<g:javascript>
  function updateNames(e) {
	// The response comes back as a bunch-o-JSON
		var names = eval("(" + e.responseText + ")") // evaluate JSON

		if (names) {
			var rselect = document.getElementById('names')

				// Clear all previous options
				var l = rselect.length

				while (l > 0) {
					l--
						rselect.remove(l)
				}

			// Rebuild the select
			for (var i=0; i < names.length; i++) {
				var city = names[i]
					var opt = document.createElement('option') 
					opt.text = city[0]
					opt.value = city[0]
					try {
						rselect.add(opt,null) // standards compliant; doesn't work in IE
					} catch(ex) {
						rselect.add(opt) // IE only
					}
			}

			if (rselect.selectedIndex >= 0) {
				updateName(rselect.options[rselect.selectedIndex].value)
			}

		}
  }

  function initNames() {
	var zselect = document.getElementById('fenlei.id')
	if (zselect) {
		if (zselect.selectedIndex >= 0) {
			var zopt = zselect.options[zselect.selectedIndex]
${remoteFunction(controller:'richangjiaoyi', 
  action:'ajaxGetJiaoYiNames',
  params:'\'fenlei=\' + escape(zopt.value)',
  onComplete:'updateNames(e)')}
		} else {
${remoteFunction(controller:'richangjiaoyi', 
  action:'ajaxGetJiaoYiNames',
  onComplete:'updateNames(e)')}
		}
	}
  }

  function updateName(v) {
	var vName = document.getElementById('name')
	if (vName)
		vName.value = v 	
  }
</g:javascript>


