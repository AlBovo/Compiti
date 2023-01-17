class Account{
    var name = ""
    var balance = 0.0
        set(value){
            require(value >= 0.0){
                "The balance must be positive"
            }
            field = value
        }
        get(){
            require(field >= 0.0) {
                "The balance must be positive"
            }
            return field
        }
    fun withdraw(quantity: Double){
        require(quantity > 0.0){
            "The quantity must be positive and not zero"
        }
        require(quantity <= balance){
            "You cannot withdraw money that you don't even have"
        }
        balance -= quantity
        println("You now have $balance€")
    }
    fun deposit(quantity: Double){
        require(quantity > 0.0){
            "You must deposit a positive quantity"
        }
        balance += quantity
        println("You now have $balance€")
    }
}

fun main(){
    var account = Account()
    account.balance = 0.0
    account.deposit(40.0)
}