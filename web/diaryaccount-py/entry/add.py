import entry.data
import logging
from google.appengine.ext import db
import gzip
import StringIO

__author__="angelstone"
__date__ ="$2010-10-10 15:51:09$"

from google.appengine.ext import webapp
from django.utils import simplejson as json
  
class BatchAddPage(webapp.RequestHandler):
  def get(self):
    self.response.headers['Content-Type'] = 'text/html'
    self.response.out.write("Use post only!")

  def post(self):
    self.response.headers['Content-Type'] = 'text/html'

    try:
      #gzip_entries_txt = StringIO.StringIO(self.request.get('entries'))
      gzip_entries_txt = StringIO.StringIO(self.request.body)
      f = gzip.GzipFile(mode='rb', fileobj=gzip_entries_txt)
      entries_txt = f.read()
      f.close()

      entries_list = json.loads(entries_txt)

      for dict in entries_list:
        e = entry.data.Entry()
        e.from_dict(dict)

        #Delete the old version
        q = db.GqlQuery('SELECT * from Entry WHERE uid = :1', e.uid)
        db.delete(q.fetch(1))

        #Save the new version
        e.put()

      self.response.out.write("1")
    except (db.Error, ValueError), err:
      logging.error("Error handle entries:'%s'" % err)
      logging.error("Error handle entries:'%s'" % entries_txt)
      self.response.out.write("Unexpected error:%s" % err.message)

