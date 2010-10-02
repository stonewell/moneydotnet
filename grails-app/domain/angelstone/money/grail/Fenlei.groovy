package angelstone.money.grail

import javax.persistence.*

@Entity
class Fenlei implements Serializable {
  @Id
  @GeneratedValue (strategy = GenerationType.IDENTITY)
  Long id

  String name
    Date updated = new Date()

    static constraints = {
        id visible:false
      name(blank:false, unique:true)
    }

    String toString() {
        "${name}"
    }
}
