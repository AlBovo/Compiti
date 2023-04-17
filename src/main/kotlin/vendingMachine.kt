import kotlin.random.Random
// Q29tcGl0byBEaSBBTEFOIERBVklERSBCT1ZP
class VendingMachine(price: Double, quantity: Int){
    private class Product(priceInitial: Double, quantityInitial: Int){
        var price = priceInitial
            set(value){
                require(value > 0.0){
                    "The new price must be positive"
                }
                field = value
            }
            get(){
                require(field > 0){
                    "The price must be positive"
                }
                return field
            }
            init{
                require(priceInitial > 0.0){
                    "The new price must be positive"
                }
                price = priceInitial
            }
        var quantity = quantityInitial
            set(value){
                require(value > 0){
                    "The new number must be positive"
                }
                field = value
            }
            get(){
                require(field > 0){
                    "The number must be positive"
                }
                return field
            }
            init{
                require(quantity > 0){
                    "The new number must be positive"
                }
                quantity = quantityInitial
            }
    }
    private var statusBroken = false
    private val product = Product(price, quantity)
    private var amount = 0.0
    private var status = false
    fun addMoney(money: Double){
        require(!statusBroken && status){
            "The vending machine cannot be broken or turned off"
        }
        require(money > 0){
            "You must add a positive quantity of money"
        }
        amount += money
        vendingMachineIsNowBroken()
        if(statusBroken){
            println("Now the vending machine is broken, please repair it")
        }
    }
    fun getRest(money: Double){
        require(!statusBroken && status){
            "The vending machine cannot be broken or turned off"
        }
        require(money > 0){
            "The get a positive quantity of rest"
        }
        amount -= money
        vendingMachineIsNowBroken()
        if(statusBroken){
            println("Now the vending machine is broken, please repair it")
        }
    }
    fun getCurrentQuantityOfMoney(): Double{
        return amount
    }
    fun updateStatus(newStatus: Boolean){
        require(!statusBroken){
            "The vending machine cannot be broken"
        }
        require(newStatus != status){
            if(status){
                "The machine is already on"
            }
            else{
                "The machine is already off"
            }
        }
        status = newStatus
    }
    fun vendingMachineIsOn(): Boolean{
        return status
    }
    fun vendingMachineIsNowBroken(brokeNow: Boolean = false){
        require(status){
            "The machine cannot be turned off"
        }
        if(brokeNow){
            status =  false
            statusBroken = true
            return
        }
        val newStatus = Random.nextInt(2) == 1
        if(newStatus){
            status =  false
            statusBroken = true
        }
    }
    fun repairVendingMachine(){
        require(statusBroken){
            "The vending machine must be broken"
        }
        statusBroken = false
    }
    fun buySnack(quantity: Int){
        require(!statusBroken && status){
            "The vending machine cannot be broken or turned off"
        }
        require(amount >= product.price*quantity){
            "You cannot buy a snack if you don't have enough money"
        }
        require(product.quantity > 0 && quantity <= product.quantity && quantity > 0){
            "You cannot buy a snack if it doesn't exit"
        }
        amount -= product.price*quantity
        product.quantity -= quantity
        vendingMachineIsNowBroken()
        if(statusBroken){
            println("Now the vending machine is broken, please repair it")
        }
    }
    fun isBroken(): Boolean{
        return statusBroken
    }
    fun getSnackPrice(): Double{
        return product.price
    }
    fun getSnackQuantity(): Int{
        return product.quantity
    }
    fun updateQuantity(quantity: Int){
        product.quantity = quantity
    }
    fun updateSnackPrice(newPrice: Double){
        product.price = newPrice
    }
}