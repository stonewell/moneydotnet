package angelstone.diaryaccount

class DiaryAccountServiceService {

  static transactional = false

  def saveEntries(def entries) {

    entries.each { jsobj ->
      def entry = new Entry(jsobj)

      Entry.withTransaction {
        if (!entry.save(flush:true)) {
          throw new Exception ("fail to save entry:" + entry.encodeAsJSON())
        }

      }

    }

    return "1"
  }
}
