# To change this template, choose Tools | Templates
# and open the template in the editor.

__author__="angelstone"
__date__ ="$2010-10-10 15:42:47$"

from google.appengine.ext import webapp

class EntryListPage(webapp.RequestHandler):
  def get(self):
    self.response.headers['Content-Type'] = 'text/plain'
    self.response.out.write('Hello, webapp World!')
