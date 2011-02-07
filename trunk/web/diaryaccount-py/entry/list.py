import entry.data
import gzip
import StringIO

__author__="angelstone"
__date__ ="$2010-10-10 15:42:47$"

from google.appengine.ext import webapp
from django.utils import simplejson as json

class EntryListPage(webapp.RequestHandler):
  def get(self):
    self.response.headers['Content-Type'] = 'text/html'
    self.response.headers['Content-Encoding'] = 'gzip'
    data = json.dumps([e.to_dict() for e in entry.data.Entry.all()])
    gzip_data=StringIO.StringIO()
    f = gzip.GzipFile(mode='wb', fileobj=gzip_data)
    f.write(data)
    f.close()
    gzip_data.seek(0)
    self.response.out.write(gzip_data.getvalue())
