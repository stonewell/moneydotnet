import logging
__author__="angelstone"
__date__ ="$2010-10-10 15:42:47$"

from google.appengine.ext import webapp
from django.utils import simplejson as json
from google.appengine.ext import db

class BatchDeletePage(webapp.RequestHandler):
  def get(self):
    post(self)
    
  def post(self):
    self.response.headers['Content-Type'] = 'text/html'
    
    uids_txt = self.request.get('uids')
    logging.info("get uid list:%s" % uids_txt)
    uids_list = json.loads(uids_txt)

    for uid in uids_list:
      logging.info("delete entry by uid:%s" % uid)
      q = db.GqlQuery('SELECT * from Entry WHERE uid = :1', uid)
      db.delete(q.fetch(1))

    self.response.out.write('1')