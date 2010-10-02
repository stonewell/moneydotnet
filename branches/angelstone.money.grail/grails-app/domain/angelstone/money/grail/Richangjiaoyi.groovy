package angelstone.money.grail

import javax.persistence.*

@Entity
class Richangjiaoyi implements Serializable {
  @Id
  @GeneratedValue (strategy = GenerationType.IDENTITY)
  Long id

  int fangxiang
    String name
    long fenlei_id
    long fangshi_id
    Date created = new Date()
    Date updated = new Date()
    double amount
    String description
	
    static constraints = {
        id visible:false
        fangxiang(blank:false,
            validator: { fx ->
                return fx==0 || fx==1
            })
        name(maxSize:50, blank:false)
        amount(blank:false,
            validator:{ amt ->
                return amt > 0
            })
        description(maxSize:255, nullable:true)
    }

    static mapping = {
        fenlei lazy:false
        fangshi lazy:false
    }
}
