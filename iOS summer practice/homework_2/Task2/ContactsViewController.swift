//
//  ContactsViewController.swift
//  Task2
//
//  Created by Данил on 02.07.2023.
//

import UIKit

final class ContactsViewController: UIViewController, UITableViewDataSource, UITableViewDelegate {

    @IBOutlet weak var contactsTableView: UITableView!
    
    private let contactsData: [ContactsListTableViewData] = [
        ContactsListTableViewData(contact: "Мама", image: UIImage(named: "phone")!),
           ContactsListTableViewData(contact: "Папа", image: UIImage(named: "phone")!),
           ContactsListTableViewData(contact: "Брат", image: UIImage(named: "phone")!),
           ContactsListTableViewData(contact: "Сергей", image: UIImage(named: "phone")!),
           ContactsListTableViewData(contact: "Василий", image: UIImage(named: "phone")!),
           ContactsListTableViewData(contact: "Булат", image: UIImage(named: "phone")!),
           ContactsListTableViewData(contact: "Илья", image: UIImage(named: "phone")!),
           ContactsListTableViewData(contact: "Олег", image: UIImage(named: "phone")!),
           ContactsListTableViewData(contact: "Игорь", image: UIImage(named: "phone")!),
           ContactsListTableViewData(contact: "Борис", image: UIImage(named: "phone")!),
           ContactsListTableViewData(contact: "Виктор", image: UIImage(named: "phone")!),
           ContactsListTableViewData(contact: "Леха", image: UIImage(named: "phone")!),
           ContactsListTableViewData(contact: "Миша", image: UIImage(named: "phone")!),
           ContactsListTableViewData(contact: "Алмаз", image: UIImage(named: "phone")!),
           ContactsListTableViewData(contact: "Никита", image: UIImage(named: "phone")!),
           ContactsListTableViewData(contact: "Клим", image: UIImage(named: "phone")!),
           ContactsListTableViewData(contact: "Марат", image: UIImage(named: "phone")!),
           ContactsListTableViewData(contact: "Елена", image: UIImage(named: "phone")!),
           ContactsListTableViewData(contact: "Рита", image: UIImage(named: "phone")!),
           ContactsListTableViewData(contact: "Маша", image: UIImage(named: "phone")!),
           ContactsListTableViewData(contact: "Даша", image: UIImage(named: "phone")!)
       ]

    override func viewDidLoad() {
        super.viewDidLoad()
        
        contactsTableView.dataSource = self
        contactsTableView.delegate = self
    }
    
    func tableView(_ tableView: UITableView, heightForRowAt indexPath: IndexPath) -> CGFloat{
        100
    }
    
    func tableView(_ tableView: UITableView, numberOfRowsInSection section: Int) -> Int {
        contactsData.count
    }
    
    func tableView(_ tableView: UITableView, cellForRowAt indexPath: IndexPath) -> UITableViewCell {
        guard let cell = contactsTableView.dequeueReusableCell(withIdentifier: "ContactsTableViewCell") as? ContactsTableViewCell else { return UITableViewCell() }
        
        cell.setUp(contactsData[indexPath.row])
        return cell
    }
}
