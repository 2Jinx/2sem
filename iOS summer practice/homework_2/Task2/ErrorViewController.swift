//
//  ErrorViewController.swift
//  Task2
//
//  Created by Данил on 02.07.2023.
//

import UIKit


class ErrorViewController: UIViewController {
    
    @IBOutlet weak var ErrorImageView: UIImageView!
    @IBOutlet weak var ErrorMessageLabel: UILabel!
    
    override func viewDidLoad() {
        super.viewDidLoad()
        
        // Do any additional setup after loading the view.
    }
    
    @IBAction func BackButtonIsPressed(_ sender: Any) {
        self.dismiss(animated: true)
    }
    
    
}
