package angelstone.diaryaccount

import grails.converters.*

class EntryController {
    
  def scaffold = true
  def index = { redirect(action:list,params:params) }

  def diaryAccountServiceService

  // the delete, save and update actions only accept POST requests
  static allowedMethods = [delete:'POST', save:'POST', update:'POST']

  def addOne = {
    def entryInstance = new Entry(params)
    Entry.withTransaction {
      if(entryInstance.save(flush:true)) {
        render String.valueOf(entryInstance.id)
      }
      else {
        render "0"
      }
    }
  }

  def batchAdd = {
    if (params.entries == null)
    render "1";
    else {
      def entries = JSON.parse(params.entries)

      try {
        render diaryAccountServiceService.saveEntries(entries)
      }catch(Exception ex) {
        render ex.getMessage()
      }
    }//else
  }

  def getAllNewEntry = {
    Long max_id = params.max_id == null ? 1 : Long.valueOf(params.max_id)
    	
    def all_entries = Entry.findAll("select id, fangxiang,name,description,amount,fenlei_name,fangshi_name,created,updated from Entry where id>=?1", [max_id])
		
    render all_entries as JSON
    	
  }
}
