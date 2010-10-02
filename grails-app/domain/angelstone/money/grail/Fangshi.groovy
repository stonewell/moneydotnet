package angelstone.money.grail

import javax.persistence.*

@Entity
class Fangshi implements Serializable {
  @Id
  @GeneratedValue (strategy = GenerationType.IDENTITY)
  Long id
	
    String name
    Date updated = new Date()

    static constraints = {
        name(blank:false, unique:true)
      id visible:false
    }

    String toString() {
        "${name}"
    }
}
