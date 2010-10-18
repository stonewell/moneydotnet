import entry.add
import entry.list
from google.appengine.ext import webapp
from google.appengine.ext.webapp.util import run_wsgi_app

application = webapp.WSGIApplication(
                                     [('/entry/list', entry.list.EntryListPage),
                                      ('/entry/batchAddEntry', entry.add.BatchAddPage)],
                                     debug=True)

def main():
  run_wsgi_app(application)

if __name__ == "__main__":
  main()