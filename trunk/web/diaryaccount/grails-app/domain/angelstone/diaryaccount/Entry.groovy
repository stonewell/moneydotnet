package angelstone.diaryaccount



import javax.persistence.*;
// import com.google.appengine.api.datastore.Key;

@Entity
class Entry implements Serializable {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    Long id

    int type
    String name
    String category
    String pay_method
    long pay_date
    long create_date
    double amount
    String description
	
    static constraints = {
        id visible:false
        type(blank:false,
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
}
