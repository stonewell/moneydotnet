package angelstone.money.grail

class Fangshi {
	
    String name
    Date updated = new Date()

    static constraints = {
        name(blank:false, unique:true)
    }

    String toString() {
        "${name}"
    }
}
