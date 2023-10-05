## Tools Are Important
Are you using the best tool for the job?


## Code without tests is bad code. 
It does’nt matter how well written it is; it does ´nt matter how pretty or object-oriented or well-encapsulated it is. With tests, we can change
the behavior of our code quickly and verifiable. Without them, we really don’t know
if our code is getting better or worse. You might think that this is severe. What about clean code? If a code base is
very clean and well structured, isn’t that enough? Well, make no mistake. I love
clean code. I love it more than most people I know, but while clean code is
good, it’s not enough. Teams take serious chances when they try to make large
changes without tests. It is like doing aerial gymnastics without a net. It
requires incredible skill and a clear understanding of what can happen at every
step

### Unit testing is one of the most important components in legacy code work

Unit tests run fast. If they don’t run fast, they aren’t unit tests.
Other kinds of tests often masquerade as unit tests. A test is not a unit test if:
1. It talks to a database.
2. It communicates across a network.
3. It touches the file system.
4. You have to do special things to your environment
   (such as editing configuration files) to run it.
   Tests that do these things aren’t bad. Often they are worth writing, and you generally
   will write them in unit test harnesses. However, it is important to be able to separate
   them from true unit tests so that you can keep a set of tests that you can run fast
   whenever you make changes
