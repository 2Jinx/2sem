//
//  ViewController.swift
//  Task2
//
//  Created by Данил on 30.06.2023.
//

import UIKit

class ViewController: UIViewController {
    
    @IBOutlet weak var PasswordTextField: UITextField!
    @IBOutlet weak var PhoneNumberTextField: UITextField!
    @IBOutlet weak var GreetingsLabel: UILabel!
    
    var correctPassword: String = "111"
    
    override func viewDidLoad() {
        super.viewDidLoad()
        // Do any additional setup after loading the view.
    }

    @IBAction func HideKeyboardAfterEditing(_ sender: Any) {
        PasswordTextField.resignFirstResponder()
        PhoneNumberTextField.resignFirstResponder()
    }
    
    @IBAction func IsButtonPressed(_ sender: Any) {
        var password = PasswordTextField.text
        var phoneNumber = PhoneNumberTextField.text
        
        PasswordTextField.text = nil
        PhoneNumberTextField.text = nil
        
        if (password != nil && phoneNumber != nil && phoneNumber?.count == 11 && phoneNumber!.hasPrefix("8908") && password == correctPassword){
            let storyboard = UIStoryboard(name: "Main", bundle: nil)
            let vc = storyboard.instantiateViewController(withIdentifier: "ContactsViewController")
            navigationController?.pushViewController(vc, animated: true)
            
            //view.backgroundColor = .systemBlue
        }else{
            let storyboard = UIStoryboard(name: "Main", bundle: nil)
            let vc = storyboard.instantiateViewController(withIdentifier: "ErrorViewController")
            present(vc, animated: true)
        }
    }
    
    
}






