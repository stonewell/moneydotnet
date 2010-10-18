import json.encoder
# To change this template, choose Tools | Templates
# and open the template in the editor.

__author__="angelstone"
__date__ ="$2010-10-10 15:51:09$"

from google.appengine.ext import webapp
from django.utils import simplejson as json

class BatchAddPage(webapp.RequestHandler):
  def get(self):
    self.response.headers['Content-Type'] = 'text/html'
    self.response.out.write('Hello, webapp Batch Add!')
    self.response.out.write(json.dumps(self.request.headers))
