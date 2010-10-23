import entry.add
import entry.list
import entry.delete

from google.appengine.ext import webapp
from google.appengine.ext.webapp.util import run_wsgi_app

application = webapp.WSGIApplication(
                                     [('/entry/list', entry.list.EntryListPage),
                                      ('/entry/batchAdd', entry.add.BatchAddPage),
                                      ('/entry/batchDelete', entry.delete.BatchDeletePage)
                                      ],
                                     debug=True)

def main():
  run_wsgi_app(application)

if __name__ == "__main__":
  main()