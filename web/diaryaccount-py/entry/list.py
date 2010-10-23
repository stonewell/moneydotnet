import entry.data

__author__="angelstone"
__date__ ="$2010-10-10 15:42:47$"

from google.appengine.ext import webapp
from django.utils import simplejson as json

class EntryListPage(webapp.RequestHandler):
  def get(self):
    self.response.headers['Content-Type'] = 'text/html'
    data = json.dumps([e.to_dict() for e in entry.data.Entry.all()])
    self.response.out.write(data)