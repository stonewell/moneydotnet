package angelstone.money.grail



import javax.persistence.*;
// import com.google.appengine.api.datastore.Key;

@Entity
class Note implements Serializable {

    @Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	Long id

    static constraints = {
    	id visible:false
	}
}
