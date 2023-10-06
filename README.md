# Individuellt-projekt-SUT23-bank2
Overview of workflow
This is one of my first project that i've done over more than a couple of days. This has been fun and exiting and I have learned a lot.
The first issue i had was how to design the program when there is 5 users. I have only built programs for 1 user before. I decided to build a unique method for each user to separate the accounts and the experiences.
I started by designing an if menu for the log in screen. I had some problems with implementing an array in the program, but after trying to do the accounts with an array and realizing what a headache that would be i decided for the usernnames and password.
After solving all of the log in issues I started with the separate user screens. I did all of the accounts with the balances. I actually decided on the balances by using a RNG I built and let it choose between 0-20 000.
When I had worked out all of the details and problems with the first user I just copied and pasted to each of the other user methods.

Manual
1. Start by login in with the correct username and password supplied by two arrays where the indexes need to match.
2. When you have entered your credentials correctly you are ready to start using the program. Now you see a Case/Switch menu with 4 options: Account/saldo, Transfer/överföring, Withdrawl/Uttag and Quit/avsluta.
3. When pressing 1 (Account/Saldo) you will see your current account balance.
4. When pressing 2 (Transfer/Överföring) You can move money between your accounts.
5. When pressing 3 (Withdrawl/Uttag) You can as the title reveals withdraw money from your account. Since I dont own a cashmachine it will only be removed from your account.
6. When pressing 4 (Quit/Avsluta) The program shuts down.

If I were to do this assignment again:
More methods for the withdrawl and transfer to clean up the code. 
Use lists for the accounts and or the users.
I made 1 method for each user. I think i just would have made a boolean be true and then take me to a universal menu. It seems easier now when i think about it.
Fun project with many things that can improve but im glad I made it work.
