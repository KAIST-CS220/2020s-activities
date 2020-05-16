module Activity12.MFIXME // FIXME = student id

// DO NOT MODIFY but FIXME
type BankAccount () =
  let mutable balance = 0u
  member __.Balance with get() = balance
  member __.Deposit amount =
    balance <- balance + amount
  member __.Withdraw amount =
    ignore amount // FIXME: you change only this.

// DO NOT MODIFY BELOW
let myfunc (initial: uint32) (amount: uint32) =
  let acc = BankAccount ()
  acc.Deposit initial
  acc.Withdraw amount
  acc.Balance
