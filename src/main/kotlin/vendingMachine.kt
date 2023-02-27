import kotlin.random.Random

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
    }
    private var statusBroken = false
    private val product = Product(price, quantity)
    private var amount = 0.0
    private var status: Boolean = false
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
            print("Now the vending machine is broken, please repair it")
            return
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
            print("Now the vending machine is broken, please repair it")
            return
        }
    }
    fun getCurrentQuantityOfMoney(): Double{
        return amount
    }
    fun updateStatus(newStatus: Boolean){
        require(!statusBroken && status){
            "The vending machine cannot be broken or turned off"
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
        vendingMachineIsNowBroken()
        if(statusBroken){
            print("Now the vending machine is broken, please repair it")
            return
        }
    }
    fun vendingMachineIsOn(): Boolean{
        return status
    }
    fun vendingMachineIsNowBroken(brokeNow: Boolean = false){
        require(status){
            "The machine must be turned off"
        }
        if(brokeNow){
            status =  false
            statusBroken = true
            return
        }
        val newStatus = Random.nextBits(1) == 1
        if(status){
            status =  !status
            statusBroken = true
        }
    }
    fun repairVendingMachine(){
        require(statusBroken && !status){
            "The vending machine must be broken"
        }
        statusBroken = !statusBroken
    }
    fun buySnack(quantity: Int){
        require(!statusBroken && status){
            "The vending machine cannot be broken or turned off"
        }
        require(amount > product.price){
            "You cannot buy a snack if you don't have enough money"
        }
        require(product.quantity > 0 && quantity <= product.quantity && quantity > 0){
            "You cannot buy a snack if it doesn't exit"
        }
        amount -= product.price
        product.price--
        vendingMachineIsNowBroken()
        if(statusBroken){
            print("Now the vending machine is broken, please repair it")
            return
        }
    }
    fun getSnackPrice(): Double{
        return product.price
    }
    fun getSnackQuantity(): Int{
        return product.quantity
    }
}