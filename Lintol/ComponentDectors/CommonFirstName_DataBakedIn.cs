using System;
using System.Collections.Generic;
using System.Linq;
using Lintol.Domain;

namespace Lintol.ComponentDectors
{
    public class CommonFirstName_DataBakedIn : IDetectComponents
    {
        private readonly InSetDetector inListDetectorDetector;

        public CommonFirstName_DataBakedIn()
        {
            var nameList =
               "william,john,david,paul,christopher,thomas,peter,mark,james,george,michael,stephen,andrew,jack,brian,daniel,arthur,robert,richard,matthew,ronald,anthony,ryan,charles,frederick,kenneth,joshua,albert,alan,ian,simon,luke,samuel,ernest,jordan,alfred,edward,adam,joseph,lee,roger,alexander,harold,derek,keith,frank,leslie,raymond,colin,kevin,darren,benjamin,henry,philip,gary,stanley,roy,steven,liam,harry,eric,donald,terence,martin,jason,jonathan,jake,walter,dennis,graham,nicholas,craig,reginald,leonard,barry,herbert,gordon,norman,neil,lewis,nigel,oliver,malcolm,timothy,stuart,geoffrey,cyril,jamie,sidney,nathan,francis,connor,percy,trevor,adrian,wilfred,patrick,scott,callum,wayne,aaron,ashley,cecil,bradley,gareth,jacob,sydney,sean,kieran,horace,bernard,carl,dean,fred,douglas,sam,edwin,gerald,shaun,ben,mohammed,clifford,maurice,kyle,clive,antony,victor,jeremy,justin,rodney,jeffrey,edgar,christian,karl,alex,dominic,joe,marc,reece,hugh,russell,gavin,lawrence,rhys,robin,phillip,denis,bryan,allan,charlie,archibald,ralph,ross,julian,tom,dale,gilbert,howard,damian,hubert,desmond,shane,cameron,duncan,louis,tony,conor,bertie,barrie,garry,elliot,marcus,percival,vincent,max,ivor,mathew,bertram,derrick,abdul,arnold,martyn,ricky,edmund,clarence,glen,mitchell,melvyn,gerard,gregory,iain,billy,roland,basil,joel,lionel,josh,leon,claude,neville,stewart,mohammad,dylan,alec,graeme,terry,guy,elliott,danny,brandon,laurence,evan,toby,hector,mohamed,ivan,bruce,brett,royston,owen,declan,glenn,leigh,noel,morris,damien,jay,jesse,mary,margaret,susan,sarah,rebecca,florence,jean,patricia,linda,julie,claire,laura,lauren,doris,joan,christine,karen,nicola,gemma,jessica,edith,dorothy,joyce,jacqueline,emma,charlotte,kathleen,janet,deborah,lisa,hannah,annie,sheila,ann,tracey,joanne,sophie,elsie,barbara,carol,jane,michelle,victoria,amy,alice,irene,doreen,elizabeth,helen,samantha,emily,june,maureen,diane,rachel,winifred,eileen,shirley,anne,sharon,gladys,betty,valerie,tracy,amanda,jennifer,chloe,angela,ethel,marjorie,sandra,louise,katie,lucy,hilda,phyllis,pauline,alison,lilian,audrey,caroline,clare,kelly,bethany,ivy,vera,brenda,gillian,natalie,jade,violet,pamela,megan,sylvia,elaine,ellen,lesley,catherine,hayley,lily,edna,danielle,nellie,beryl,holly,wendy,abigail,mabel,olivia,ada,dawn,donna,stephanie,beatrice,olive,leanne,rita,carole,may,evelyn,natasha,rose,mavis,denise,sally,katherine,georgia,iris,judith,maria,zoe,kerry,debra,melanie,stacey,eleanor,gertrude,muriel,paula,shannon,marion,joanna,paige,agnes,marina,janice,lorraine,georgina,jessie,peggy,rosemary,lynn,andrea,frances,suzanne,nicole,grace,josephine,yvonne,chelsea,lynne,anna,kirsty,eva,gwendoline,alexandra,constance,norma,beverley,melissa,kimberley,hazel,fiona,kate,marie,jenna,marilyn,jodie,daisy,nora,minnie,freda,mandy,rachael,maud,lynda,tina,kathryn,molly,nancy,ruth,jayne,amber,diana,marian,jasmine,veronica,sara,kayleigh,louisa,dora,daphne,teresa,harriet,julia,ashleigh,norah,heather,kim,jemma,thelma,carly,leah,ida,clara,gloria,francesca,naomi,hilary,abbie,jill,martha,cynthia,bertha,katy,lillian,cheryl,rosie,ruby,aimee,enid,marlene,vanessa,ellie,bessie,sian,gail,lydia,mildred,penelope,charlene,hollie,isabella,christina,annette,bethan,jeanette,amelia,esther,carolyn,beth,anita,geraldine,bridget,lindsey,kay,stella,lindsay,ella,robyn,eliza,nichola,chantelle,rosina,heidi,demi,millicent,monica,theresa,courtney,margery,maxine,tanya,carla,gabrielle,fanny,joy,yasmin,alma,glenys,rhiannon,debbie,jenny,blanche,vivienne,tara,miriam,glynis,clair,lyndsey,imogen,sonia,rebekah,michele,lynsey,caitlin,sybil,toni";

            var names = nameList.Split(',').ToList();

            inListDetectorDetector = new InSetDetector(names, ComponentType.Firstname, s => s.ToLower());
        }

        public Component Detect(Word word)
        {
            return inListDetectorDetector.Detect(word);
        }
    }
}