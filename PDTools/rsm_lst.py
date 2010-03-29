#create pa2_[001-025].cs.lst where each file contains 
#"C:\Documents and Settings\gjing\workspace\PDTools\samples\pa2_NNN.cs"

for i in range(1,26):
	if i < 10:
		filen = "C:\Documents and Settings\gjing\M2 RSM 

Wizard\input\pa2_00%s.cs.lst"  % (i,)
		content = "C:\Documents and 

Settings\gjing\workspace\PDTools\samples\pa2_00%s.cs" % (i,)
		print filen, "#", content
		p = open(filen, mode='w')#, encoding='utf-8')
		p.write(content)	
	else :
		filen = "C:\Documents and Settings\gjing\M2 RSM Wizard\input\pa2_0%s.cs.lst" 

 % (i,)
		content = "C:\Documents and 

Settings\gjing\workspace\PDTools\samples\pa2_0%s.cs" % (i,)
		print filen, "#", content
		p = open(filen, mode='w')#, encoding='utf-8')
		p.write(content)