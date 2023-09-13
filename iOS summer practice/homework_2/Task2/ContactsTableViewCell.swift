//
//  ContactsTableViewCell.swift
//  Task2
//
//  Created by Данил on 02.07.2023.
//

import UIKit

struct ContactsListTableViewData {
    let contact:  String
    let image: UIImage
}

final class ContactsTableViewCell: UITableViewCell {
    @IBOutlet weak var contactImageView: UIImageView!
    @IBOutlet weak var contactLabel: UILabel!
    
    override init(style: UITableViewCell.CellStyle, reuseIdentifier: String?) {
        super.init(style: style, reuseIdentifier: reuseIdentifier)
        
        contactLabel.backgroundColor = .systemGray6
        contactLabel.layer.cornerRadius = 16
    }
    
    required init?(coder: NSCoder) {
        super.init(coder: coder)
        
    }
    
    override func prepareForReuse() {
        super.prepareForReuse()
        
        contactLabel.text = nil
        contactImageView.image = nil
    }
    
    func setUp(_ data: ContactsListTableViewData){
        contactLabel.text = data.contact
        contactImageView.image = data.image
    }
}
