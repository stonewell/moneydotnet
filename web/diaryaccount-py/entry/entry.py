# To change this template, choose Tools | Templates
# and open the template in the editor.

__author__="angelstone"
__date__ ="$2010-10-21 21:49:53$"

from google.appengine.ext import db

class Entry(db.Model):
  author = db.UserProperty()
  content = db.StringProperty(multiline=True)
  date = db.DateTimeProperty(auto_now_add=True)
    int type
    String name
    String category
    String pay_method
    long pay_date
    long create_date
    double amount
    String description
    String uid
    deleted = db.BoolPropery()
