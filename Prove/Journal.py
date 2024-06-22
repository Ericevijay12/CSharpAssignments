import datetime
import random
import json

class Entry:
    def __init__(self, prompt, response):
        self.date = datetime.datetime.now().strftime("%Y-%m-%d %H:%M:%S")
        self.prompt = prompt
        self.response = response

    def __str__(self):
        return f"{self.date}\nPrompt: {self.prompt}\nResponse: {self.response}\n"

class Journal:
    def __init__(self):
        self.entries = []
        self.prompts = [
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?"
        ]

    def add_entry(self):
        prompt = random.choice(self.prompts)
        response = input(f"{prompt}\n> ")
        entry = Entry(prompt, response)
        self.entries.append(entry)

    def display_journal(self):
        for entry in self.entries:
            print(entry)

    def save_journal(self, filename):
        with open(filename, 'w') as file:
            json.dump([entry.__dict__ for entry in self.entries], file, indent=4)

    def load_journal(self, filename):
        self.entries = []
        try:
            with open(filename, 'r') as file:
                entries_data = json.load(file)
                for entry_data in entries_data:
                    entry = Entry(entry_data['prompt'], entry_data['response'])
                    entry.date = entry_data['date']
                    self.entries.append(entry)
        except FileNotFoundError:
            print("File not found.")

def main():
    journal = Journal()

    while True:
        print("\nJournal Menu")
        print("1. Write a new entry")
        print("2. Display the journal")
        print("3. Save the journal to a file")
        print("4. Load the journal from a file")
        print("5. Exit")

        choice = input("Choose an option: ")
        
        if choice == '1':
            journal.add_entry()
        elif choice == '2':
            journal.display_journal()
        elif choice == '3':
            filename = input("Enter the filename to save to: ")
            journal.save_journal(filename)
        elif choice == '4':
            filename = input("Enter the filename to load from: ")
            journal.load_journal(filename)
        elif choice == '5':
            break
        else:
            print("Invalid choice. Please try again.")

if __name__ == "__main__":
    main()
