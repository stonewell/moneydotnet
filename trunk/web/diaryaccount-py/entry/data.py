# To change this template, choose Tools | Templates
# and open the template in the editor.

__author__="angelstone"
__date__ ="$2010-10-21 21:49:53$"

from google.appengine.ext import db

class Entry(db.Model):
  type = db.IntegerProperty()
  name = db.StringProperty()
  category = db.StringProperty()
  pay_method = db.StringProperty()
  pay_date = db.IntegerProperty()
  create_date = db.IntegerProperty()
  amount = db.FloatProperty()
  description = db.StringProperty(multiline=True)
  uid = db.StringProperty()
  deleted = db.IntegerProperty()

  def to_dict(self):
       return dict([(p, getattr(self, p)) for p in self.properties()])

  def from_dict(self, dict):
    for key in dict.keys():
      if (key == 'amount') :
        setattr(self, key, float(dict[key]))
      else:
        setattr(self, key, dict[key])