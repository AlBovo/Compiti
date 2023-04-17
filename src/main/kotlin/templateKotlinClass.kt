// Q29tcGl0byBEaSBBTEFOIERBVklERSBCT1ZP
class BankAccount{
    var name = ""
    get(){
        field = name
        require(field != ""){
            "Name must be initialized"
        }
        return field
    }
    set(value){
        require(field != ""){
            "Name must be initialized"
        }
        name = value
    }

}

fun main(){
    var myAccount = BankAccount()

}